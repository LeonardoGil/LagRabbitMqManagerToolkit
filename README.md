# LagRabbitMqManagerToolkit

![Status](https://img.shields.io/badge/status-em%20desenvolvimento-yellow)
![NuGet](https://img.shields.io/nuget/v/LagRabbitMqManagerToolkit?color=blue)

## 🧠 Descrição

LagRabbitMqManagerToolkit é uma biblioteca em .NET que facilita a integração com o RabbitMQ Management Plugin utilizando chamadas HTTP diretas à API de administração do RabbitMQ. 
Ela permite consultar de forma prática informações sobre filas, mensagens, exchanges e outros recursos administrativos sem a necessidade de lidar com os detalhes da API REST manualmente.

## 🚧 Status do Projeto

O projeto está em constante desenvolvimento. Algumas funcionalidades essenciais já foram implementadas, enquanto outras ainda estão em construção.

## 🚀 Exemplo prático

```csharp

public class Exemplo(IQueueService queueService, IExchangeService exchangeService)
{
  public void Queue()
  {
    // Credencial Default "RabbitSettings.Default();"
    var settings = new RabbitSettings
    {
      Username = "guest",
      Password = "guest",
      Url = "http://localhost:15672/"
    };

    // Dados da Fila
    var queue = await _queueRequest.GetAsync("/", "Exemplo");


    // Listar mensagens (Consome a mensagem e retorna a fila)
    var messages = await _queueRequest.GetMessagesAsync(queue.Vhost, queue.Name);


    // Publicar mensagem
    var properties = new Dictionary<string, string>()
    {
      { "message_id", Guid.NewGuid().ToString() }
    };

    var payload = "<teste></teste>";

    await _exchangeRequest.PublishAsync(queue.Vhost, queue.Name, properties, payload);    
  }
}

```

## 📦 Tecnologias Utilizadas

- .NET 8
- C# 12
- xUnit

## 🤝 Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues, sugerir melhorias ou enviar pull requests.

