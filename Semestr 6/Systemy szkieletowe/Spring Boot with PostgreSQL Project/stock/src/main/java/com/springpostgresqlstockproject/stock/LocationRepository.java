package com.springpostgresqlstockproject.stock;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public class LocationRepository {

    @Autowired
    JdbcTemplate jdbcTemplate;

    public List<Location> getAllLocations() {
        return jdbcTemplate.query("SELECT id, loc_row, loc_column, loc_shelf FROM location",
                BeanPropertyRowMapper.newInstance(Location.class));
    }
}
