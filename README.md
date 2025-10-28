# 💉 Dominando Injeção de Dependência em C#

> Repositório criado para consolidar meus estudos sobre **Injeção de Dependência (DI)**, **Inversão de Controle (IoC)** e o **Princípio da Inversão de Dependência (DIP)** em aplicações C#.

---

## 🧠 Sobre o projeto

Este repositório contém exemplos práticos e conceitos fundamentais aprendidos durante o curso **“Dominando Injeção de Dependência”**, que aborda de forma completa como aplicar corretamente os princípios de **IoC** e **DIP** em projetos .NET.

O objetivo é compreender como a **injeção de dependência** melhora o **desacoplamento**, **testabilidade** e **manutenibilidade** do código.

---

## 📚 Conteúdos abordados

- Conceitos de **Inversão de Controle (IoC)** e **Injeção de Dependência (DI)**
- Aplicando o **Princípio da Inversão de Dependência (DIP)** na prática
- Tipos de injeção:
  - Injeção por **construtor**
  - Injeção por **propriedade**
  - Injeção por **método**
- Uso de **containers de injeção de dependência** no .NET
- Boas práticas e **antipadrões** a evitar
- Estruturação de **camadas** e **interfaces**
- Benefícios da **testabilidade** e **mocking**

---

## 🧩 Tecnologias utilizadas

- **.NET 8**
- **C#**
- **Microsoft.Extensions.DependencyInjection**

---

// Interface
public interface IMensagemService
{
    void Enviar(string mensagem);
}

// Implementação concreta
public class EmailService : IMensagemService
{
    public void Enviar(string mensagem)
    {
        Console.WriteLine($"E-mail enviado: {mensagem}");
    }
}

// Classe dependente
public class Notificador
{
    private readonly IMensagemService _mensagemService;

    public Notificador(IMensagemService mensagemService)
    {
        _mensagemService = mensagemService;
    }

    public void Notificar(string mensagem)
    {
        _mensagemService.Enviar(mensagem);
    }
}

// Configuração via injeção
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IMensagemService, EmailService>();
var app = builder.Build();

var notificador = app.Services.GetRequiredService<Notificador>();
notificador.Notificar("Curso finalizado com sucesso!");
---
🏁 Resultado do aprendizado

Após concluir este projeto e o curso "Dominando Injeção de Dependência", adquiri um entendimento sólido sobre:

O papel e benefícios da injeção de dependência no .NET

Como estruturar aplicações desacopladas e de fácil manutenção

Como aplicar o DIP na prática com exemplos reais

🧑‍💻 Autor

Matheus Jhonatas
💼 QA | Desenvolvedor .NET em formação
📘 Estudando Clean Architecture, SOLID e boas práticas em C#
🔗 LinkedIn
