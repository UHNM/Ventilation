
using DAL.Repositories;
using Domain.Entities.Complex;
using Domain.Models;

namespace BAL.Managers.DefaultImplementations
{
    public class PrescriptionManager : IPrescriptionManager
    {
        private readonly IPrescriptionRepository _dynamicResponseRepository;


        public PrescriptionManager(IPrescriptionRepository dynamicResponseRepository)
        {
            _dynamicResponseRepository = dynamicResponseRepository;
        }

        public async Task<List<PrescriptionQuestion>> GetPrescriptionQuestions(int? equipmentId, int? prescriptionId)
        {
            var prescriptionEquipmentProperties =  _dynamicResponseRepository.GetPrescriptionEquipmentProperties(equipmentId);
            var prescriptionPropertyResponses = _dynamicResponseRepository.GetPrescriptionResponses(prescriptionId);

            var t = Task.WhenAll(
                prescriptionEquipmentProperties,
                prescriptionPropertyResponses);
            await t;

            //get a list of the properties for a piece of equipment
            List<EquipmentProperty> equipProperties = new List<EquipmentProperty>();
            equipProperties = GetEquipmentPropertyFromDto(await prescriptionEquipmentProperties);

            //get a list of any responses that have been set for those properties
            List<PrescriptionProperty> prescProperties = new List<PrescriptionProperty>();
            prescProperties = GetPrescriptionPropertyFromDto(await prescriptionPropertyResponses);

            List<PrescriptionQuestion> prescriptionQuestions = new List<PrescriptionQuestion>();

            //loop thru the equipment properties and mnatch up any responses
            foreach (EquipmentProperty equipprop in equipProperties)
            {
                PrescriptionQuestion q = new PrescriptionQuestion();
                q.Id = equipprop.Id;
                q.EquipmentId = equipprop.EquipmentId;
                q.Required = equipprop.Required;    
                q.uiControlType = equipprop.uiControlType;
                q.Type = equipprop.Type;
                q.Order = equipprop.Order;
                q.DisplayName = equipprop.DisplayName;

                foreach (PrescriptionProperty resp in prescProperties)
                {
                    if(equipprop.Id == resp.EquipmentPropertyId)
                    {
                        q.ResponseInteger = resp.PrescriptionPropertyResponseInteger;
                        q.ResponseBool = resp.PrescriptionPropertyResponseBool;
                        q.ResponseString = resp.PrescriptionPropertyResponseString;
                        q.ResponseDateTime = resp.PrescriptionPropertyResponseDateTime;
                    }
                }
            prescriptionQuestions.Add(q);
            }

            return prescriptionQuestions;
        }

        private static List<EquipmentProperty> GetEquipmentPropertyFromDto(IEnumerable<EquipmentPropertyCx> Dto)
        {
            if (Dto != null)
            {
                List<EquipmentProperty> equipProperties = new List<EquipmentProperty>();

                foreach (EquipmentPropertyCx equip in Dto)
                {
                    EquipmentProperty s = new EquipmentProperty();
                    s.Id = equip.Id;
                    s.EquipmentId = equip.EquipmentId;
                    s.Required = equip.Required;
                    s.uiControlType = equip.uiControlType;
                    s.Type = equip.Type;
                    s.Order = equip.Order;
                    s.DisplayName = equip.DisplayName;

                    equipProperties.Add(s);
                }

                return equipProperties;
            }
            return null;
        }

        private static List<PrescriptionProperty> GetPrescriptionPropertyFromDto(IEnumerable<PrescriptionPropertyCx> Dto)
        {
            if (Dto != null)
            {
                List<PrescriptionProperty> prescProperties = new List<PrescriptionProperty>();

                foreach (PrescriptionPropertyCx prescript in Dto)
                {
                    PrescriptionProperty p = new PrescriptionProperty();
                    p.Id = prescript.Id;
                    p.EquipmentPropertyId = prescript.EquipmentPropertyId;
                    p.PrescriptionPropertyResponseString = prescript.PrescriptionPropertyResponseString;
                    p.PrescriptionPropertyResponseBool = prescript.PrescriptionPropertyResponseBool;
                    p.PrescriptionPropertyResponseDateTime = prescript.PrescriptionPropertyResponseDateTime;
                    p.PrescriptionPropertyResponseInteger = prescript.PrescriptionPropertyResponseInteger;

                    prescProperties.Add(p);
                }

                return prescProperties;
            }
            return null;
        }
    }
}
