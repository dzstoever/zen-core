using Zen.Util;
using Zen.Util.Domain;
using Zen.Util.Generator;

namespace Zen.Utility
{
    public class ApplicationController
    {
        public ApplicationController(ApplicationPreferences applicationPreferences, Table table)
        {
            _applicationPreferences = applicationPreferences;
            _codeGenerator = new CodeGenerator(applicationPreferences, table);
            _fluentGenerator = new FluentGenerator(applicationPreferences, table);
            _entityFrameworkGenerator = new EntityFrameworkGenerator(applicationPreferences, table);
            _castleGenerator = new CastleGenerator(applicationPreferences, table);
            _contractGenerator = new ContractGenerator(applicationPreferences, table);
            _byCodeGenerator = new ByCodeGenerator(applicationPreferences, table);
            //if (applicationPreferences.ServerType == ServerType.Oracle)
            //{
            //    mappingGenerator = new OracleMappingGenerator(applicationPreferences, table);
            //}
            //else
            //{
            _mappingGenerator = new SqlMappingGenerator(applicationPreferences, table);
            //}
        }


        public string GeneratedDomainCode { get; set; }
        public string GeneratedMapCode { get; set; }     

        private readonly CodeGenerator _codeGenerator;
        private readonly MappingGenerator _mappingGenerator;        
        private readonly ContractGenerator _contractGenerator;
        private readonly CastleGenerator _castleGenerator;        
        private readonly FluentGenerator _fluentGenerator;        
        private readonly ByCodeGenerator _byCodeGenerator;
        private readonly EntityFrameworkGenerator _entityFrameworkGenerator;
        private readonly ApplicationPreferences _applicationPreferences;


        public void Generate(bool writeToFile = true)
        {
            _codeGenerator.Generate(writeToFile);
            GeneratedDomainCode = _codeGenerator.GeneratedCode;

            if (_applicationPreferences.IsFluent)
            {
                _fluentGenerator.Generate(writeToFile);
                GeneratedMapCode = _fluentGenerator.GeneratedCode;
            }
            if (_applicationPreferences.IsEntityFramework)
            {
                _entityFrameworkGenerator.Generate(writeToFile);
                GeneratedMapCode = _entityFrameworkGenerator.GeneratedCode;
            }
            else if (_applicationPreferences.IsCastle)
            {
                _castleGenerator.Generate(writeToFile);
                GeneratedMapCode = _castleGenerator.GeneratedCode;
            }
            else if (_applicationPreferences.IsByCode)
            {
                _byCodeGenerator.Generate(writeToFile);
                GeneratedMapCode = _byCodeGenerator.GeneratedCode;
            }
            else
            {
                _mappingGenerator.Generate(writeToFile);
                GeneratedMapCode = _mappingGenerator.GeneratedCode;
            }

            if(_applicationPreferences.GenerateWcfDataContract)
            {
                _contractGenerator.Generate(writeToFile);
            }
        }
    }
}