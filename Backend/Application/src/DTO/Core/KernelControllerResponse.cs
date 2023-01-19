using Newtonsoft.Json;

namespace Application.Dto {

    public class KernelErrorResponse {
        public string Subject { get; set; }
        public string Message { get; set; }

        public KernelErrorResponse(string subject, string message) {
            Subject = subject;
            Message = message;
        }
    }

    public class KernelControllerResponse<T> where T : class {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<KernelErrorResponse>? Errors { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Result { get; }

        public KernelControllerResponse() {}

        public KernelControllerResponse(T result) {
            Result = result;
        }

        public KernelControllerResponse<T> AddError(KernelErrorResponse kernelErrorResponse) {
            if (Errors == null) {
                Errors = new();
            }

            Errors.Add(kernelErrorResponse);

            return this;
        }

        public KernelControllerResponse<T> AddError(string subject, string message) {
            return this.AddError(new KernelErrorResponse(subject, message));
        }

        public KernelControllerResponse<T> AddNotFoundError() {
            return this.AddError((new KernelErrorResponse("NotFoundError", "Entity was not found")));
        }
    }

}
