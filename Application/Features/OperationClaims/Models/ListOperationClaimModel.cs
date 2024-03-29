﻿using Application.Features.OperationClaims.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Models
{
    public class ListOperationClaimModel:BasePageableModel
    {
        public IList<ListOperationClaimDto> Items { get; set; }
    }
}
