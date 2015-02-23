using Moq;
using Xbehave;
using Zen.Ux;

namespace Zen.Test.Scenarios.Ux
{
    public class NavigationScenarios 
    {
        /* Todo...
         *
        [Scenario]
        public virtual void NavigatorCanLaunchOtherViewWindow()
        {
            var navigator = new Mock<IAppController>();
            var factory = new Mock<IViewFactory>();
            var mainView = new Mock<IMainView>();
            var view1 = new Mock<IView>();

            "Given ".Given(() =>
            {
                factory.Setup(f => f.CreateView<IView>()).Returns(view1.Object);
                view1.Setup(v => v.Show()).Verifiable();
            });

            "When ".When(() =>
            {
                //var viewmodel = new MainWindowVM(factory.Object);
                //viewmodel.Launch.Execute(null);                
            });
            "Then ".Then(view1.VerifyAll);

        }
                 
        [Scenario]
		public void ShowHelpShouldCallMainViewsHelp()
		{
			var factory = new Mock<IViewFactory>();
			var mainView = new Mock<IMainView>();
			
            factory.Setup(f => f.CreateView<IMainView>()).Returns(mainView.Object);
			mainView.Setup(v => v.ShowHelp()).Verifiable();

			var viewmodel = new MainWindowVM(factory.Object)
			                	{
			                		ParentView = mainView.Object
			                	};
			viewmodel.ShowHelp.Execute(null);

			mainView.VerifyAll();
		}
         * 
        [Scenario]
        public virtual void NavigatorCanLaunchNonViewScreen()
        { }
                
        [Scenario]
        public virtual void NavigatorCanLaunchMainViewWindow()
        { }
        */

    }
}
