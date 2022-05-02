using System.Collections.Generic;

namespace QuidProGo.Models.ViewModels
{
    public class ConsultationCreateViewModel
    {
        public Consultation Consultation { get; set; }
        public List<UserProfile> AttorneyList { get; set; }
        public List<Category> CategoryList { get; set; }

    }
}
