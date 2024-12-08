package com.springpostgresqlstockproject.stock;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface LocationRepository extends JpaRepository<Location, Integer> {
    // Wszystkie metody CRUD są automatycznie dostarczane przez JpaRepository.
}
