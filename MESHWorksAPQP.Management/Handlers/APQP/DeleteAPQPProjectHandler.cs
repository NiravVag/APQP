namespace MESHWorksAPQP.Management.Handlers.APQP
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.APQP;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.APQP;

    /// <summary>
    /// Delete APQP project 
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler&lt;MESHWorksAPQP.Management.Command.APQP.DeleteAPQPProjectCommand&gt;" />
    public class DeleteAPQPProjectHandler : ICommandHandler<DeleteAPQPProjectCommand>
    {
        private readonly IAPQPManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteAPQPProjectHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public DeleteAPQPProjectHandler(IAPQPManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(DeleteAPQPProjectCommand command)
        {
            command.Result = await this.manager.DeleteAPQPProject(command);
        }
    }
}
