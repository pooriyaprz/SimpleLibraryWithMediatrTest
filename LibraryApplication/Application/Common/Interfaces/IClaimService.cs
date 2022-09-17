using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IClaimService
    {
        Task<List<Claim>> GetValidClaims(ApplicationUser user);
    }
}
