using System;
using Intersoft.Crosslight.Data.EntityModel;

namespace Angalia.Core.Models
{
    public class Setting : EntityBase
    {
        #region Constructors

        public Setting()
        {
            this.HospitalRadius = 1000;
            this.HospitalRadiusValue = 500;

            this.PharmacyRadius = 1000;
            this.PharmacyRadiusValue = 500;
        }

        #endregion

        #region Properties

        public int HospitalRadius
        {
            get { return (int) this.GetValue(HospitalRadiusPropertyMetadata); }
            set { this.SetValue(HospitalRadiusPropertyMetadata, value); }
        }
        
        public int HospitalRadiusValue
        {
            get { return (int) this.GetValue(HospitalRadiusValuePropertyMetadata); }
            set { this.SetValue(HospitalRadiusValuePropertyMetadata, value); }
        }

        public int PharmacyRadius
        {
            get { return (int)this.GetValue(PharmacyRadiusPropertyMetadata); }
            set { this.SetValue(PharmacyRadiusPropertyMetadata, value); }
        }

        public int PharmacyRadiusValue
        {
            get { return (int)this.GetValue(PharmacyRadiusValuePropertyMetadata); }
            set { this.SetValue(PharmacyRadiusValuePropertyMetadata, value); }
        }

        #endregion

        #region Constants

        public static EntityProperty HospitalRadiusPropertyMetadata = EntityMetadata.Register(new DataEntityProperty<Setting, int>("HospitalRadius", false));

        public static EntityProperty HospitalRadiusValuePropertyMetadata = EntityMetadata.Register(new DataEntityProperty<Setting, int>("HospitalRadiusValue", false));

        public static EntityProperty PharmacyRadiusPropertyMetadata = EntityMetadata.Register(new DataEntityProperty<Setting, int>("PharmacyRadius", false));

        public static EntityProperty PharmacyRadiusValuePropertyMetadata = EntityMetadata.Register(new DataEntityProperty<Setting, int>("PharmacyRadiusValue", false));

        public static implicit operator Setting(Settings v)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}