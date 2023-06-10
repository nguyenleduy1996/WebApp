using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.CommonDTO
{
    public class ApiResult<T>
    {
        public bool IsSuccessed { get; set; }

        public string Message { get; set; }

        public string[] ValidationErrors { get; set; }

        public T ResultObj { get; set; }

        public ApiResult<T> SuccesResult(T resultObj, string Message)
        {
            var result = new ApiResult<T>();
            result.IsSuccessed = true;
            result.Message = Message;
            result.ResultObj = resultObj;
            return result;
        }
        public ApiResult<T> FailResult(string[] validationErrors)
        {
            var result = new ApiResult<T>();
            result.IsSuccessed = false;
            result.ValidationErrors = validationErrors;
            return result;
        }
        public ApiResult<T> FailResult(string Message)
        {
            var result = new ApiResult<T>();
            result.IsSuccessed = false;
            result.Message = Message;
            return result;
        }
    }
}
