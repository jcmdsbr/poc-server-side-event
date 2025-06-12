# 🚀 Prova de Conceito de Server-Side Events (SSE)

Este projeto demonstra a implementação de Server-Side Events (SSE) em uma aplicação .NET. SSE é uma tecnologia que permite que o servidor envie atualizações para o cliente através de uma única conexão HTTP.

## 🤔 O que são Server-Side Events (SSE)?

Server-Side Events (SSE) é uma tecnologia que permite que servidores enviem dados para clientes web através do HTTP. Diferente do WebSocket, que é um protocolo de comunicação bidirecional, o SSE é um canal de comunicação unidirecional do servidor para o cliente. É construído sobre HTTP padrão, tornando-o mais simples de implementar e mais amigável com firewalls.

### 🎯 Características Principais do SSE

- **Comunicação Unidirecional**: Apenas do servidor para o cliente
- **HTTP Padrão**: Usa conexões HTTP normais
- **Reconexão Automática**: Mecanismo de reconexão embutido
- **Baseado em Eventos**: Mensagens são enviadas como eventos
- **Baseado em Texto**: Dados são transmitidos como texto UTF-8
- **Suporte Nativo do Navegador**: Suportado pela maioria dos navegadores modernos

## ⚙️ Como o SSE Funciona

1. **Estabelecimento da Conexão**:
   - Cliente inicia uma requisição HTTP normal
   - Servidor responde com `Content-Type: text/event-stream`
   - Conexão permanece aberta para comunicação servidor-cliente

2. **Formato da Mensagem**:
 
   ```
   event: nomeDoEvento
   data: {"chave": "valor"}
   id: 123
   retry: 3000
   ```

3. **Componentes Principais**:
   - `event`: Identificador opcional do tipo de evento
   - `data`: Conteúdo real da mensagem
   - `id`: Identificador único da mensagem
   - `retry`: Tempo de reconexão em milissegundos

4. **Implementação do Cliente**:

   ```javascript
   const eventSource = new EventSource('/api/events');
   eventSource.onmessage = (event) => {
     console.log(event.data);
   };
   ```

## 🌟 CloudEvents e a Sinergia com SSE

CloudEvents é uma especificação para descrever dados de eventos de uma maneira comum. Quando combinado com SSE, fornece uma abordagem padronizada para arquiteturas orientadas a eventos.

### 🎁 Benefícios de Usar CloudEvents com SSE

1. **Formato Padronizado de Eventos**:
   - Estrutura consistente de eventos entre diferentes sistemas
   - Metadados bem definidos para cada evento
   - Melhor interoperabilidade entre serviços

2. **Contexto Aprimorado do Evento**:
   - Identificação da fonte
   - Especificação do tipo de evento
   - Informações de timestamp e versão
   - Rastreamento de correlação e causalidade

3. **Exemplo de Formato CloudEvents com SSE**

   ```
   event: user.created
   data: {
     "specversion": "1.0",
     "id": "1234-5678-9012",
     "source": "/user-service",
     "type": "com.example.user.created",
     "datacontenttype": "application/json",
     "data": {
       "userId": "123",
       "name": "John Doe"
     }
   }
   ```

4. **Casos de Uso**:
   - Notificações em tempo real
   - Atualizações de dados ao vivo
   - Monitoramento de sistema
   - Microsserviços orientados a eventos
   - Atualizações de dispositivos IoT

## ✨ Funcionalidades

- Comunicação em tempo real servidor-cliente
- Conexão HTTP persistente
- Atualizações baseadas em eventos
- Implementação simples e eficiente
- Integração com CloudEvents
- Formato de evento padronizado

## 📋 Pré-requisitos

- .NET 10 (PREVIEW) SDK

## 🚀 Como Começar

1. Clone o repositório:

```bash
git clone https://github.com/jcmdsbr/poc-server-side-event.git
```

2. Navegue até o diretório do projeto:

```bash
cd PocServerSideEvent
```

3. Compile e execute o projeto:

```bash
dotnet build
dotnet run
```

## 💡 Como Usar

A aplicação demonstra como:

- Configurar um endpoint SSE
- Enviar atualizações em tempo real para clientes conectados
- Gerenciar conexões e desconexões de clientes
- Implementar comunicação baseada em eventos
- Formatar eventos usando a especificação CloudEvents
- Lidar com diferentes tipos de eventos
- Implementar estratégias de reconexão

## 🎯 Boas Práticas

1. **Tratamento de Erros**:
   - Implemente tratamento adequado para problemas de conexão
   - Use o mecanismo de retry de forma efetiva
   - Trate diferentes tipos de eventos apropriadamente

2. **Segurança**:
   - Implemente autenticação para conexões SSE
   - Use HTTPS para comunicação segura
   - Valide dados de eventos

3. **Performance**:
   - Monitore o número de conexões
   - Implemente limpeza adequada para clientes desconectados
   - Use tamanhos de buffer apropriados

## 📄 Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo [LICENSE](LICENSE) para mais detalhes.