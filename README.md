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
* * **Model do paginacji**
