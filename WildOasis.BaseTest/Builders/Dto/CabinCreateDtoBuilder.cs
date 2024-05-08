using WildOasis.Application.Common.Dto.Cabin;
using WildOasis.Domain.Enums;

namespace WildOasis.BaseTest.Builders.Dto;

    public class CabinCreateDtoBuilder
    {
        private Guid _resortId = Guid.NewGuid();
        private string _name = "-";
        private string _description = "testtesttshysb";
        private int _maxCapacity = 3;
        private int _regularPrice = 80;
        private int _discount = 10;
        private string _image = "imagestring";
        private int _category = 1;

        public CabinCreateDto Build() => new CabinCreateDto(_resortId, _name, _description, _maxCapacity, _regularPrice, _discount, _image,_category);
        
        public CabinCreateDtoBuilder WithResortId(Guid resortId)
        {
            _resortId = resortId;
            return this;
        }

        public CabinCreateDtoBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
        
        public CabinCreateDtoBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }
        
        public CabinCreateDtoBuilder WithMaxCapacity(int maxCapacity)
        {
            _maxCapacity = maxCapacity;
            return this;
        }

        public CabinCreateDtoBuilder WithRegularPrice(int regularPrice)
        {
            _regularPrice = regularPrice;
            return this;
        }

        public CabinCreateDtoBuilder WithDiscount(int discount)
        {
            _discount = discount;
            return this;
        }

        public CabinCreateDtoBuilder WithImage(string image)
        {
            _image = image;
            return this;
        }
    }
