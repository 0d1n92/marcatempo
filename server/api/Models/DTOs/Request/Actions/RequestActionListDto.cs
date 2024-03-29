﻿using api.Utilitis.Enum;
using System.Collections.Generic;

namespace api.DTOs;
    public class RequestActionListDto
    {
       public string InitDate { get; set; }
       public string EndDate { get; set; }    
       public List<string> SortBy { get; set; }
       public List<bool> SortDesc { get; set; }
       public EnumUserPresent Present { get; set; }
       public IList<string> UsersName { get; set; }
        
    }

