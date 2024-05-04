package com.springpostgresqlstockproject.stock;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository // adnotacja służy do wskazania, że klasa zapewnia mechanizm przechowywania, pobierania, wyszukiwania, aktualizacji i usuwania obiektów
public class ItemRepository {

    @Autowired  // Pozwala ona Springowi na rozwiązywanie i wstrzykiwanie współpracujących beanów do naszego beanu (Beany to dowolne obiekty zarządzane przez kontener Springa).
    JdbcTemplate jdbcTemplate;

     public List<Item> getAllItems() {
         return jdbcTemplate.query("SELECT id, ean, brand, size, color, locationId FROM item",
                 BeanPropertyRowMapper.newInstance(Item.class));    // Używamy mapera, aby przetłumaczyć dane z bazy na model obiektowy
     }
}
