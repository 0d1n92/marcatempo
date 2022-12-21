using System.Collections.Generic;

namespace api.DTOs;
    public class RequestActionListDto
    {
       public string InitDate { get; set; }
       public string EndDate { get; set; }
       public IList<string> UsersName { get; set; }
        
    }

