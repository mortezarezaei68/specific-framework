using System.ComponentModel.DataAnnotations;

namespace Framework.Exception.Exceptions.Enum
{
    public enum ResultCode
    {
        [Display(Name = "it's done")]
        Success = 0,

        [Display(Name = "the server has a problem")]
        ServerError = 1,

        [Display(Name = "the parameters have a problem")]
        BadRequest = 2,

        [Display(Name = "not found")]
        NotFound = 3,


        [Display(Name = "list is empty")]
        ListEmpty = 4,

        [Display(Name = "error in execute")]
        LogicError = 5,

        [Display(Name = "unauthorized")]
        UnAuthorized = 6,
        
                
        [Display(Name = "your data not active")]
        NotActive = 7,

    }
}
