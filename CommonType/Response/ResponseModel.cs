using System.Collections.Generic;

namespace CommonType.Response
{
    public class ResponseModel<T>
    {
        public ResponseModel(int _respCode, List<T> _data)
        {
            RespCode = _respCode;
            Data = _data;
            TotalCount = _data.Count;

        }
        public int RespCode { get; set; }


        public List<T> Data { get; set; }

        public int TotalCount { get; set; }


    }
}
