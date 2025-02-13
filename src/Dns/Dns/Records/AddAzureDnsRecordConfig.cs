﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Dns
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Management.Dns.Models;
    using ProjectResources = Microsoft.Azure.Commands.Dns.Properties.Resources;

    /// <summary>
    /// Adds a record to a record set object.
    /// </summary>
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DnsRecordConfig"), OutputType(typeof(DnsRecordSet))]
    public class AddAzureDnsRecordConfig : DnsBaseCmdlet
    {
        private const string ParameterSetCaa = "Caa";

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The record set in which to add the record.")]
        [ValidateNotNullOrEmpty]
        public DnsRecordSet RecordSet { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The IPv4 address for the A record to add.", ParameterSetName = "A")]
        [ValidateNotNullOrEmpty]
        public string Ipv4Address { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The IPv6 address for the AAAA record to add.", ParameterSetName = "AAAA")]
        [ValidateNotNullOrEmpty]
        public string Ipv6Address { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name server host for the NS record to add. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "NS")]
        [ValidateNotNullOrEmpty]
        public string Nsdname { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The mail exchange host for the MX record to add. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "MX")]
        [ValidateNotNullOrEmpty]
        public string Exchange { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The preference value for the MX record to add.", ParameterSetName = "MX")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The preference field of the NAPTR record to add.", ParameterSetName = "NAPTR")]
        [ValidateNotNullOrEmpty]
        public ushort Preference { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The target host for the PTR record to add. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "PTR")]
        [ValidateNotNullOrEmpty]
        public string Ptrdname { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The text value for the TXT record to add.", ParameterSetName = "TXT")]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The priority value SRV record to add.", ParameterSetName = "SRV")]
        [ValidateNotNullOrEmpty]
        public ushort Priority { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The target host for the SRV record to add. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "SRV")]
        [ValidateNotNullOrEmpty]
        public string Target { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The port number for the SRV record to add.", ParameterSetName = "SRV")]
        [ValidateNotNullOrEmpty]
        public ushort Port { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The weight value for the SRV record to add.", ParameterSetName = "SRV")]
        [ValidateNotNullOrEmpty]
        public ushort Weight { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The canonical name for the CNAME record to add. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "CNAME")]
        [ValidateNotNullOrEmpty]
        public string Cname { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The flags for the CAA record to add. Must be a number between 0 and 255.", ParameterSetName = ParameterSetCaa)]
        [ValidateNotNullOrEmpty]
        public byte CaaFlags { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The tag field of the CAA record to add.", ParameterSetName = ParameterSetCaa)]
        [ValidateNotNullOrEmpty]
        public string CaaTag { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The value field for the CAA record to add.", ParameterSetName = ParameterSetCaa)]
        [ValidateNotNull]
        [AllowEmptyString]
        [ValidateLength(DnsRecordBase.CaaRecordMinLength, DnsRecordBase.CaaRecordMaxLength)]
        public string CaaValue { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The key tag field of the DS record to add.", ParameterSetName = "DS")]
        [ValidateNotNullOrEmpty]
        public int KeyTag { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The algorithm field of the DS record to add.", ParameterSetName = "DS")]
        [ValidateNotNullOrEmpty]
        public int Algorithm { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The digest type field of the DS record to add.", ParameterSetName = "DS")]
        [ValidateNotNullOrEmpty]
        public int DigestType { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The digest field of the DS record to add.", ParameterSetName = "DS")]
        [ValidateNotNullOrEmpty]
        public string Digest { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The usage field of the TLSA record to add.", ParameterSetName = "TLSA")]
        [ValidateNotNullOrEmpty]
        public int Usage { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The selector field of the TLSA record to add.", ParameterSetName = "TLSA")]
        [ValidateNotNullOrEmpty]
        public int Selector { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The matching type field of the TLSA record to add.", ParameterSetName = "TLSA")]
        [ValidateNotNullOrEmpty]
        public int MatchingType { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The certificate association data field of the TLSA record to add.", ParameterSetName = "TLSA")]
        [ValidateNotNullOrEmpty]
        public string CertificateAssociationData { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The order field of the NAPTR record to add.", ParameterSetName = "NAPTR")]
        [ValidateNotNullOrEmpty]
        public ushort Order { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The flags field of the NAPTR record to add.", ParameterSetName = "NAPTR")]
        [ValidateNotNullOrEmpty]
        public string Flags { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The service field of the NAPTR record to add.", ParameterSetName = "NAPTR")]
        [ValidateNotNullOrEmpty]
        public string Services { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The regular expression field of the NAPTR record to add.", ParameterSetName = "NAPTR")]
        [ValidateNotNull]
        [AllowEmptyString]
        public string Regexp { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The replacement field of the NAPTR record to add.", ParameterSetName = "NAPTR")]
        [ValidateNotNullOrEmpty]
        public string Replacement { get; set; }

        public override void ExecuteCmdlet()
        {
            var result = this.RecordSet;
            if (!string.Equals(this.ParameterSetName, this.RecordSet.RecordType.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(string.Format(ProjectResources.Error_AddRecordTypeMismatch, this.ParameterSetName, this.RecordSet.RecordType));
            }

            if (result.Records == null)
            {
                result.Records = new List<DnsRecordBase>();
            }

            switch (result.RecordType)
            {
                case RecordType.A:
                    {
                        result.Records.Add(new ARecord { Ipv4Address = this.Ipv4Address });
                        break;
                    }

                case RecordType.Aaaa:
                    {
                        result.Records.Add(new AaaaRecord { Ipv6Address = this.Ipv6Address });
                        break;
                    }

                case RecordType.MX:
                    {
                        result.Records.Add(new MxRecord { Preference = this.Preference, Exchange = this.Exchange });
                        break;
                    }

                case RecordType.NS:
                    {
                        result.Records.Add(new NsRecord { Nsdname = this.Nsdname });
                        break;
                    }
                case RecordType.SRV:
                    {
                        result.Records.Add(new SrvRecord { Priority = this.Priority, Port = this.Port, Target = this.Target, Weight = this.Weight });
                        break;
                    }
                case RecordType.TXT:
                    {
                        result.Records.Add(new TxtRecord { Value = this.Value });
                        break;
                    }
                case RecordType.PTR:
                    {
                        result.Records.Add(new PtrRecord { Ptrdname = this.Ptrdname });
                        break;
                    }
                case RecordType.Cname:
                    {
                        if (result.Records.Count != 0)
                        {
                            var currentCNameRecord = result.Records[0] as CnameRecord;
                            if (currentCNameRecord == null)
                            {
                                throw new ArgumentException(ProjectResources.Error_AddRecordTypeMismatch);
                            }

                            if (!string.IsNullOrEmpty(currentCNameRecord.Cname))
                            {
                                throw new ArgumentException(ProjectResources.Error_AddRecordMultipleCnames);
                            }

                            result.Records.Clear();
                        }

                        result.Records.Add(new CnameRecord { Cname = this.Cname });
                        break;
                    }
                case RecordType.CAA:
                    {
                        result.Records.Add(new CaaRecord { Flags = this.CaaFlags, Tag = this.CaaTag, Value = this.CaaValue });
                        break;
                    }
                case RecordType.DS:
                    {
                        result.Records.Add(new DsRecord { KeyTag = this.KeyTag, Algorithm = this.Algorithm, DigestType = this.DigestType, Digest = this.Digest });
                        break;
                    }
                case RecordType.Tlsa:
                    {
                        result.Records.Add(new TlsaRecord { Usage = this.Usage, Selector = this.Selector, MatchingType = this.MatchingType, CertificateAssociationData = this.CertificateAssociationData });
                        break;
                    }
                case RecordType.Naptr:
                    {
                        result.Records.Add(new NaptrRecord { Order = this.Order, Preference = this.Preference, Flags = this.Flags, Services = this.Services, Regexp = this.Regexp, Replacement = this.Replacement });
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            WriteVerbose(ProjectResources.Success_RecordAdded);

            WriteObject(result);
        }
    }
}
