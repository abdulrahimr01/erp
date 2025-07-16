-- PROCEDURE: public.sp_category(character varying, character varying, character varying, boolean, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_category(character varying, character varying, character varying, boolean, bigint);

CREATE OR REPLACE PROCEDURE public.sp_category(
	IN p_name character varying,
	IN p_actionby character varying,
	IN p_notes character varying,
	IN p_isactive boolean,
	IN p_id bigint DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
 -- Insert
  IF p_id = 0 THEN
    INSERT INTO category(
      name, actionby, notes, isactive
    )
    VALUES (
      p_name, p_actionby, p_notes, p_isactive
    );
  END IF;

  -- Update
  IF p_id > 0 AND EXISTS (SELECT 1 FROM category WHERE id = p_id) THEN
    UPDATE category
    SET name = p_name,
        actionby = p_actionby,
        notes = p_notes,
        isactive = p_isactive
    WHERE id = p_id;
  END IF;
END;
$BODY$;
ALTER PROCEDURE public.sp_category(character varying, character varying, character varying, boolean, bigint)
    OWNER TO postgres;
