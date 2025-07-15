-- PROCEDURE: public.sp_hsn(character varying, character varying, character varying, character varying, character varying, character varying, character varying, boolean, integer)

-- DROP PROCEDURE IF EXISTS public.sp_hsn(character varying, character varying, character varying, character varying, character varying, character varying, character varying, boolean, integer);

CREATE OR REPLACE PROCEDURE public.sp_hsn(
	IN p_categoryid character varying,
	IN p_name character varying,
	IN p_notes character varying,
	IN p_gst character varying,
	IN p_sgst character varying,
	IN p_cgst character varying,
	IN p_actionby character varying,
	IN p_isactive boolean,
	IN p_id integer DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
  -- Insert
  IF p_id = 0 THEN
    INSERT INTO hsn (
      categoryid, name, notes, gst, sgst,
      cgst, actionby, isactive
    )
    VALUES (
      p_categoryid, p_name, p_notes, p_gst, p_sgst,
      p_cgst, p_actionby, p_isactive
    );
  END IF;

  -- Update
  IF p_id > 0 AND EXISTS (SELECT 1 FROM hsn WHERE id = p_id) THEN
    UPDATE hsn
    SET
      categoryid = p_categoryid,
      name = p_name,
      notes = p_notes,
      gst = p_gst,
      sgst = p_sgst,
      cgst = p_cgst,
      actionby = p_actionby,
      isactive = p_isactive
    WHERE id = p_id;
  END IF;
END;
$BODY$;
ALTER PROCEDURE public.sp_hsn(character varying, character varying, character varying, character varying, character varying, character varying, character varying, boolean, integer)
    OWNER TO postgres;
