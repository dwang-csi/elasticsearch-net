﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Stores a search template that can be used to pre render search requests,
		/// before they are executed and fill the search template with template parameters.
		/// </summary>
		[Obsolete("Removed in NEST 6.x. In NEST 6.x, use the PutScript API to store templates")]
		IPutSearchTemplateResponse PutSearchTemplate(Id id, Func<PutSearchTemplateDescriptor, IPutSearchTemplateRequest> selector);

		/// <summary>
		/// Stores a search template that can be used to pre render search requests,
		/// before they are executed and fill the search template with template parameters.
		/// </summary>
		[Obsolete("Removed in NEST 6.x. In NEST 6.x, use the PutScript API to store templates")]
		IPutSearchTemplateResponse PutSearchTemplate(IPutSearchTemplateRequest request);

		/// <summary>
		/// Stores a search template that can be used to pre render search requests,
		/// before they are executed and fill the search template with template parameters.
		/// </summary>
		[Obsolete("Removed in NEST 6.x. In NEST 6.x, use the PutScript API to store templates")]
		Task<IPutSearchTemplateResponse> PutSearchTemplateAsync(Id id, Func<PutSearchTemplateDescriptor, IPutSearchTemplateRequest> selector,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <summary>
		/// Stores a search template that can be used to pre render search requests,
		/// before they are executed and fill the search template with template parameters.
		/// </summary>
		[Obsolete("Removed in NEST 6.x. In NEST 6.x, use the PutScript API to store templates")]
		Task<IPutSearchTemplateResponse> PutSearchTemplateAsync(IPutSearchTemplateRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		[Obsolete("Removed in NEST 6.x. In NEST 6.x, use the PutScript API to store templates")]
		public IPutSearchTemplateResponse PutSearchTemplate(Id id, Func<PutSearchTemplateDescriptor, IPutSearchTemplateRequest> selector) =>
			PutSearchTemplate(selector?.Invoke(new PutSearchTemplateDescriptor(id)));

		/// <inheritdoc />
		[Obsolete("Removed in NEST 6.x. In NEST 6.x, use the PutScript API to store templates")]
		public IPutSearchTemplateResponse PutSearchTemplate(IPutSearchTemplateRequest request) =>
			Dispatcher.Dispatch<IPutSearchTemplateRequest, PutSearchTemplateRequestParameters, PutSearchTemplateResponse>(
				request,
				LowLevelDispatch.PutTemplateDispatch<PutSearchTemplateResponse>
			);

		/// <inheritdoc />
		[Obsolete("Removed in NEST 6.x. In NEST 6.x, use the PutScript API to store templates")]
		public Task<IPutSearchTemplateResponse> PutSearchTemplateAsync(Id id, Func<PutSearchTemplateDescriptor, IPutSearchTemplateRequest> selector,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			PutSearchTemplateAsync(selector?.Invoke(new PutSearchTemplateDescriptor(id)), cancellationToken);

		/// <inheritdoc />
		[Obsolete("Removed in NEST 6.x. In NEST 6.x, use the PutScript API to store templates")]
		public Task<IPutSearchTemplateResponse> PutSearchTemplateAsync(IPutSearchTemplateRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			Dispatcher
				.DispatchAsync<IPutSearchTemplateRequest, PutSearchTemplateRequestParameters, PutSearchTemplateResponse, IPutSearchTemplateResponse>(
					request,
					cancellationToken,
					LowLevelDispatch.PutTemplateDispatchAsync<PutSearchTemplateResponse>
				);
	}
}