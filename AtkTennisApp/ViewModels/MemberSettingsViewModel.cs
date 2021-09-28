using AtkTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class MemberSettingsViewModel
    {
        public List<CabinetType> cabinetTypes { get; set; } = new List<CabinetType>();
        public List<CabinetOperations> cabinetOperations { get; set; } = new List<CabinetOperations>();
        public List<MemberDuesType> memberDuesTypes { get; set; } = new List<MemberDuesType>();
    }
}
