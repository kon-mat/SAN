package com.springpostgresqlstockproject.stock;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/items")
public class ItemController {

    @Autowired
    ItemRepository itemRepository;

    // Pobranie wszystkich przedmiotów z bazy
    @GetMapping("")
    public List<Item> getAllItems() {
        return itemRepository.findAll();
    }

    // Pobranie przedmiotu po ID
    @GetMapping("/{id}")
    public Item getItemById(@PathVariable("id") Long id) {
        return itemRepository.findById(id).orElse(null);
    }

    // Dodanie nowego przedmiotu do bazy
    @PostMapping("")
    public Item addItemToStock(@RequestBody Item item) {
        return itemRepository.save(item); // Zwraca zapisany obiekt
    }

    // Aktualizacja istniejącego przedmiotu
    @PatchMapping("/{id}")
    public Item updateItem(@PathVariable("id") Long id, @RequestBody Item updatedItem) {
        return itemRepository.findById(id).map(item -> {
            if (updatedItem.getEan() != null) item.setEan(updatedItem.getEan());
            if (updatedItem.getBrand() != null) item.setBrand(updatedItem.getBrand());
            if (updatedItem.getSize() != null) item.setSize(updatedItem.getSize());
            if (updatedItem.getColor() != null) item.setColor(updatedItem.getColor());
            if (updatedItem.getLocationId() > 0) item.setLocationId(updatedItem.getLocationId());
            return itemRepository.save(item); // Zapisujemy zmiany
        }).orElse(null);
    }

    // Usunięcie przedmiotu po ID
    @DeleteMapping("/{id}")
    public void deleteItem(@PathVariable("id") Long id) {
        itemRepository.deleteById(id);
    }

    // Testowy endpoint do logowania Hibernate
    @GetMapping("/test-add-item")
    public String testAddItem() {
        Item item = new Item();
        item.setEan("123456789");
        item.setBrand("TestBrand");
        item.setSize("L");
        item.setColor("Red");
        item.setLocationId(1);
        itemRepository.save(item);
        return "Test item added successfully!";
    }
}
