-- PROCEDURE: public.sp_supplier(character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, boolean, integer)

-- DROP PROCEDURE IF EXISTS public.sp_supplier(character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, boolean, integer);

CREATE OR REPLACE PROCEDURE public.sp_supplier(
	IN p_typeid character varying,
	IN p_name character varying,
	IN p_gst character varying,
	IN p_landline character varying,
	IN p_email character varying,
	IN p_contact character varying,
	IN p_mobile character varying,
	IN p_address character varying,
	IN p_actionby character varying,
	IN p_isactive boolean,
	IN p_id integer DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
  -- Insert
  IF p_id = 0 THEN
    INSERT INTO supplier(
      typeid, name, gst, landline, email,
      contact, mobile, address, actionby, isactive
    )
    VALUES (
      p_typeid, p_name, p_gst, p_landline, p_email,
      p_contact, p_mobile, p_address, p_actionby, p_isactive
    );
  END IF;

  -- Update
  IF p_id > 0 AND EXISTS (SELECT 1 FROM supplier WHERE id = p_id) THEN
    UPDATE supplier
    SET
      typeid = p_typeid,
      name = p_name,
      gst = p_gst,
      landline = p_landline,
      email = p_email,
      contact = p_contact,
      mobile = p_mobile,
      address = p_address,
      actionby = p_actionby,
      isactive = p_isactive
    WHERE id = p_id;
  END IF;
END;
$BODY$;
ALTER PROCEDURE public.sp_supplier(character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, boolean, integer)
    OWNER TO postgres;
