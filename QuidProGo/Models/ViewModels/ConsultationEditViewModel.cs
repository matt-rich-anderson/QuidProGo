using System.Collections.Generic;

namespace QuidProGo.Models.ViewModels
{
    public class ConsultationEditViewModel
    {
        public Consultation Consultation { get; set; }        
        public List<UserProfile> AttorneyOptions { get; set; }
        public List<Category> CategoryOptions { get; set; }
        public List<int> SelectedCategoryIds { get; set; }
        public List<int> Edited { get; set; }

    }
}
