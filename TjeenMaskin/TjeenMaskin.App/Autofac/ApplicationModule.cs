using Autofac;
using TjeenMaskin.App.Foos.Implementations;

namespace TjeenMaskin.App.Autofac;

public class ApplicationModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    RegisterFoo(builder);
  }
  
  private void RegisterFoo(ContainerBuilder builder)
  {
     builder.RegisterType<FooEmanuel>().AsImplementedInterfaces();
  }
}

  /*
   *
 *
 
 builder.Register<CreditCard>(
  (c, p) =>
    {
      var accountId = p.Named<string>("accountId");
      if (accountId.StartsWith("9"))
      {
        return new GoldCard(accountId);
      }
      else
      {
        return new StandardCard(accountId);
      }
    });
 *
 *
 * 
 */