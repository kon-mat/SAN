package com.springpostgresqlstockproject.stock;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Repository // adnotacja służy do wskazania, że klasa zapewnia mechanizm przechowywania, pobierania, wyszukiwania, aktualizacji i usuwania obiektów
public class ItemRepository {

    @Autowired  // Pozwala ona Springowi na rozwiązywanie i wstrzykiwanie współpracujących beanów do naszego beanu (Beany to dowolne obiekty zarządzane przez kontener Springa).
    JdbcTemplate jdbcTemplate;

     public List<Item> getAllItems() {
         return jdbcTemplate.query("SELECT id, ean, brand, size, color, locationId FROM item",
                 BeanPropertyRowMapper.newInstance(Item.class));    // Używamy mapera, aby przetłumaczyć dane z bazy na model obiektowy
     }

     public Item getItemById(int id) {

         return jdbcTemplate.queryForObject(
                 "SELECT id, ean, brand, size, color, locationId FROM item WHERE id = ?",
                 BeanPropertyRowMapper.newInstance(Item.class), id);
     }

    @Transactional  // Metoda jest transakcyjna. Jeśli wystąpi błąd, transakcja zostanie automatycznie cofnięta.
    public int addItemToStock(Item item) {
        try {
            return jdbcTemplate.update(
                    "INSERT INTO item (EAN, brand, size, color, locationId) VALUES (?, ?, ?, ?, ?)",
                    item.getEan(), item.getBrand(), item.getSize(), item.getColor(), item.getLocationId()
            );
        } catch (Exception e) {
            // Obsługa błędu lub wyjątku, jeśli wystąpi
            e.printStackTrace();
            throw new RuntimeException("Failed to add item to stock", e);
        }

    }
}
