package com.springpostgresqlstockproject.stock;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

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

    @GetMapping("/{id}")
    public Item getItemById(@PathVariable("id") int id) {   // adnotacja @PathVariable odnosi się do zmiennej podanej w adresie, czyli {id}
        return itemRepository.getItemById(id);
    }

    @PostMapping("")
    public int addItemToStock(@RequestBody Item item) {     // adnotacja @PathBody odnosi się do JSON uwzględnionego w request
        return itemRepository.addItemToStock(item);
    }

}
