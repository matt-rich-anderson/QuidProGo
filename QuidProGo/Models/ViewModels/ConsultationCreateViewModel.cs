using System.Collections.Generic;

namespace QuidProGo.Models.ViewModels
{
    public class ConsultationCreateViewModel
    {
        public Consultation Consultation { get; set; }        
        public List<UserProfile> AttorneyOptions { get; set; }
        public List<Category> CategoryOptions { get; set; }
        public List<int> SelectedCategoryIds { get; set; }

    }
}
