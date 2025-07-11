-- PROCEDURE: public.sp_businesstype(character varying, character varying, character varying, boolean, integer)

-- DROP PROCEDURE IF EXISTS public.sp_businesstype(character varying, character varying, character varying, boolean, integer);

CREATE OR REPLACE PROCEDURE public.sp_businesstype(
	IN p_name character varying,
	IN p_notes character varying,
	IN p_actionby character varying,
	IN p_isactive boolean,
	IN p_id integer DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
  -- Insert
  IF p_id = 0 THEN
    INSERT INTO businesstype (
      name, notes, actionby, isactive
    )
    VALUES (
      p_name, p_notes, p_actionby, p_isactive
    );
  END IF;

  -- Update
  IF p_id > 0 AND EXISTS (SELECT 1 FROM businesstype WHERE id = p_id) THEN
    UPDATE businesstype
    SET
      name = p_name,
      notes = p_notes,
      actionby = p_actionby,
      isactive = p_isactive
    WHERE id = p_id;
  END IF;
END;
$BODY$;
ALTER PROCEDURE public.sp_businesstype(character varying, character varying, character varying, boolean, integer)
    OWNER TO postgres;
