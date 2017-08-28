using Autofac;
using Owin;

namespace CalorieCalculator.API
{

    public static class StartUp
    {
        public static void Configuration(IAppBuilder app)
        {
            var container = AutofacConfig.Initialize(Registration);
            app.UseAutofacMiddleware(container);
        }

        public static void Registration(ContainerBuilder builder)
        {
            builder.RegisterType<ValidatePatientInfo>().As<IValidator<double>>().SingleInstance();
        }
    }
}
