# Użycie

* **`AddApiResponseWrapper`**
  Rejestracja wrappera do automatycznego opakowywania odpowiedzi w spójny format JSON `{"data": ...}`
* **`RegisterDomainEventHandlers`**
  Rejestracja handlerów eventów
* **`UseGlobalExceptions`**
  Rejestracje middleware do globalnej obsługi wyjątków
* **`AddSharedInfrastructure`**
  Rejestracja serwisów takich jak: `IDateTimeProvider`, `IUnitOfWork`, `IDomainEventsDispatcher`, `ExceptionHandlerMiddleware`
* **`AddPostgres`**
  Rejestracja bazy danych postgres

# Wdrożone funkcjonalności

* **AggregateRoot**
* **Entity**
* **TypedId**
* **Unit of Work**  
* **Generyczne Repozytorium**   
* **Domain Events**
* **Automatyczne Formatowanie Odpowiedzi API**
    Wszystkie odpowiedzi z API są automatycznie opakowywane w spójny format JSON `{"data": ...}` za pomocą globalnego filtra akcji.
* **Obsługa Wyjątków**
    Zaimplementowano scentralizowany mechanizm obsługi wyjątków. Różne **rodzaje wyjątków** (np. `NotFoundException`) są mapowane na odpowiednie kody statusu HTTP, co zapewnia przewidywalne i spójne zachowanie API.
* **Statyczny Dostawca Daty (Clock)**
* **Model do paginacji**
