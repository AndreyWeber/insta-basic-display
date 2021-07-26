using InstaBasicDisplayConsole.Services;

namespace InstaBasicDisplayConsole.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly InstragramService instragramService;

        public RepositoryBase(InstragramService instragramService) =>
            this.instragramService = instragramService;
    }
}