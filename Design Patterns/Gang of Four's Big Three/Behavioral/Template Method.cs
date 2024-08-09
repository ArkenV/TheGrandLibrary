using System;

namespace TemplateMethodPattern
{
  // Abstract base class defining the template method
  abstract class DocumentProcessor
  {
    // Template method
    public void ProcessDocument()
    {
      OpenDocument();
      ExtractContent();
      ParseContent();
      AnalyzeContent();
      GenerateReport();
      CloseDocument();
    }

    protected virtual void OpenDocument()
    {
      Console.WriteLine("Opening document...");
    }

    protected virtual void CloseDocument()
    {
      Console.WriteLine("Closing document...");
    }

    protected virtual void GenerateReport()
    {
      Console.WriteLine("Generating report...");
    }

    protected abstract void ExtractContent();
    protected abstract void ParseContent();
    protected abstract void AnalyzeContent();
  }

  // Concrete Processors
  class PdfDocumentProcessor : DocumentProcessor
  {
    protected override void ExtractContent()
    {
      Console.WriteLine("Extracting content from PDF...");
    }

    protected override void ParseContent()
    {
      Console.WriteLine("Parsing PDF content...");
    }

    protected override void AnalyzeContent()
    {
      Console.WriteLine("Analyzing PDF content...");
    }
  }

  class WordDocumentProcessor : DocumentProcessor
  {
    protected override void ExtractContent()
    {
      Console.WriteLine("Extracting content from Word document...");
    }

    protected override void ParseContent()
    {
      Console.WriteLine("Parsing Word document content...");
    }

    protected override void AnalyzeContent()
    {
      Console.WriteLine("Analyzing Word document content...");
    }

    protected override void GenerateReport()
    {
      Console.WriteLine("Generating enhanced report for Word document...");
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Processing PDF document:");
      DocumentProcessor pdfProcessor = new PdfDocumentProcessor();
      pdfProcessor.ProcessDocument();

      Console.WriteLine("\nProcessing Word document:");
      DocumentProcessor wordProcessor = new WordDocumentProcessor();
      wordProcessor.ProcessDocument();
    }
  }
}