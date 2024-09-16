using AutoMapper;
using System.Globalization;

namespace ClinicaApp.Crosscutting
{
    public class EntityToDTOMaper : Profile
    {
        public EntityToDTOMaper() 
        {
            var culture = new CultureInfo("pt-BR");
            culture.NumberFormat.NumberDecimalSeparator = ",";
            
           
        
        
        
        }
    }
}
