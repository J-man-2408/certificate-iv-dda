ALTER VIEW actors_starting_with_L AS
SELECT 
    actor_id,
    first_name,
    last_name,
    last_update
FROM actor
WHERE first_name LIKE 'L%';

SELECT * FROM actors_starting_with_L;


ALTER VIEW actor_film_counts AS
SELECT 
   actor.first_name,
   actor.last_name,
   COUNT(film_actor.film_id) AS film_count
FROM actor
JOIN film_actor ON actor.actor_id = film_actor.actor_id
GROUP BY actor.actor_id, actor.first_name, actor.last_name
ORDER BY film_count DESC;

SELECT * FROM actor_film_counts;



SELECT COUNT(*) 
FROM actor
WHERE first_name LIKE 'L%';

SELECT COUNT(*) FROM actor;

SELECT * FROM film_actor;