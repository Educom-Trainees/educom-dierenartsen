using BackendASP.Models.DTO;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendASP.UnitTests.Database
{
    internal static class CustomExpressions
    {
        public static ResolvableConstraintExpression Available(this ConstraintExpression constraint)
        {
            return constraint.Property(nameof(TimeSlotDTO.Available));
        }

    }
}
