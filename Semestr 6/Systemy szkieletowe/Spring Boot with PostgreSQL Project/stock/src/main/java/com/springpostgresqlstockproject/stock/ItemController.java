package com.springpostgresqlstockproject.stock;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController // Wyspecjalizowaną wersja kontrolera. Zawiera adnotacje @Controller i @ResponseBody, a w rezultacie upraszcza implementację kontrolera.
@RequestMapping("/items")   // Służy do mapowania rquest'ów na określone klasy obsługi i/lub metody obsługi.
public class ItemController {

    @Autowired
    ItemRepository itemRepository;  // Wstrzyknięcie zależności

    @GetMapping("")
    public List<Item> getAllItems() {
        return itemRepository.getAllItems();
    }

}