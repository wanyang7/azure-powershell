// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.Management.ManagementPartner
{
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// Extension methods for PartnerOperations
    /// </summary>
    public static partial class PartnerOperationsExtensions
    {
        /// <summary>
        /// Get the management partner using the partnerId, objectId and tenantId.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='partnerId'>
        /// Id of the Partner
        /// </param>
        public static PartnerResponse Get(this IPartnerOperations operations, string partnerId)
        {
                return ((IPartnerOperations)operations).GetAsync(partnerId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get the management partner using the partnerId, objectId and tenantId.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='partnerId'>
        /// Id of the Partner
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<PartnerResponse> GetAsync(this IPartnerOperations operations, string partnerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.GetWithHttpMessagesAsync(partnerId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Create a management partner for the objectId and tenantId.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='partnerId'>
        /// Id of the Partner
        /// </param>
        public static PartnerResponse Create(this IPartnerOperations operations, string partnerId)
        {
                return ((IPartnerOperations)operations).CreateAsync(partnerId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a management partner for the objectId and tenantId.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='partnerId'>
        /// Id of the Partner
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<PartnerResponse> CreateAsync(this IPartnerOperations operations, string partnerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.CreateWithHttpMessagesAsync(partnerId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Update the management partner for the objectId and tenantId.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='partnerId'>
        /// Id of the Partner
        /// </param>
        public static PartnerResponse Update(this IPartnerOperations operations, string partnerId)
        {
                return ((IPartnerOperations)operations).UpdateAsync(partnerId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Update the management partner for the objectId and tenantId.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='partnerId'>
        /// Id of the Partner
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<PartnerResponse> UpdateAsync(this IPartnerOperations operations, string partnerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.UpdateWithHttpMessagesAsync(partnerId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Delete the management partner for the objectId and tenantId.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='partnerId'>
        /// Id of the Partner
        /// </param>
        public static void Delete(this IPartnerOperations operations, string partnerId)
        {
                ((IPartnerOperations)operations).DeleteAsync(partnerId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delete the management partner for the objectId and tenantId.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='partnerId'>
        /// Id of the Partner
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task DeleteAsync(this IPartnerOperations operations, string partnerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            (await operations.DeleteWithHttpMessagesAsync(partnerId, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }
    }
}
