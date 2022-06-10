using FluentScheduler;

namespace nCroner.Core.Models
{
    public class TriggerTypeDataModel : TypeDataModel
    {
        public string TriggerRoute { get; set; }
        public Schedule Schedule { get; set; }
    }
}