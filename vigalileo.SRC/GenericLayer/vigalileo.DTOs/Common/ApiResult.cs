using System;
using System.Collections.Generic;
using vigalileo.Utilities.Constants;

namespace vigalileo.DTOs.Common
{
    public class ApiResult<T>
    {
        public int Code { get; set; }
        public bool IsSuccessed { get; set; }
        public T Data { get; set; }
        public List<string> Messages { get; set; }

        public ApiResult(T defaultData)
        {
            Code = (int) ApiResultConstants.CODE.ERROR;
            IsSuccessed = false;
            Data = defaultData;
            Messages = new List<string>();
            Messages.Add(ApiResultConstants.MESSAGE(ApiResultConstants.CODE.ERROR));
        }

        public void SetResult(int code, bool isSuccessed, T data, params string[] messages)
        {
            Code = code;
            IsSuccessed = isSuccessed;
            Data = data;

            Messages = new List<string>();
            foreach (var mess in messages)
            {
                Messages.Add(mess);
            }
        }
    }
}