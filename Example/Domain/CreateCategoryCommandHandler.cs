using TeamSL.Infrastructure.Data;
using TeamSL.Infrastructure.Domain.Commands;
using TeamSL.Infrastructure.Example.Data;

namespace TeamSL.Infrastructure.Example.Domain
{
    public class CreateCategoryCommand : ICommand
    {
        public string Name { get; }

        public CreateCategoryCommand(string name)
        {
            Name = name;
        }
    }

    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
    {
        private readonly IRepository<CategoryRecord> _categoryRepository;

        public CreateCategoryCommandHandler(IRepository<CategoryRecord> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Execute(CreateCategoryCommand command)
        {
            _categoryRepository.Create(new CategoryRecord {Name = command.Name});
        }
    }
}