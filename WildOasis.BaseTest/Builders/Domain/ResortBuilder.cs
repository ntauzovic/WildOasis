using WildOasis.Domain.Entities;

namespace WildOasis.BaseTest.Builders.Domain;

public class ResortBuilder
{
    private  string _name = "resort12";
    private  string _description = "testtesttshysb";
    private  uint _number = 3442;
    
    private string _addres = "adressist";
    
    public Resort Build()=>new 
     (_name,_description,_addres,_number);
    
    
    public ResortBuilder withName(string name)
    {
        _name = name;
        return this;
    }
    
    public ResortBuilder withDescription(string description)
    {
        _description = description;
        return this;
    }
    public ResortBuilder WithNumber(uint number)
    {
        _number = number;
        return this;
    }
        
    public ResortBuilder withAddres(string addres)
    {
        _addres = addres;
        return this;
    }


   
}