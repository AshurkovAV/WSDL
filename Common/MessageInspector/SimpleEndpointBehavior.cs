using System.ServiceModel.Description;

namespace WSDLTest.Common.MessageInspector
{
    public class SimpleEndpointBehavior : IEndpointBehavior
    {

        public void AddBindingParameters(ServiceEndpoint endpoint,
            System.ServiceModel.Channels.BindingParameterCollection bindingParameters)

        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint,
            System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)

        {

            clientRuntime.MessageInspectors.Add(
                new SimpleMessageInspector()

                );

        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint,
            System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)

        {
        }

        public void Validate(ServiceEndpoint endpoint)

        {
        }

    }
}
