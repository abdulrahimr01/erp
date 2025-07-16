-- PROCEDURE: public.sp_menu(character varying, character varying, character varying, character varying, character varying, boolean, character varying, timestamp without time zone, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_menu(character varying, character varying, character varying, character varying, character varying, boolean, character varying, timestamp without time zone, bigint);

CREATE OR REPLACE PROCEDURE public.sp_menu(
	IN p_menuname character varying,
	IN p_submenuname character varying,
	IN p_menupath character varying,
	IN p_submenupath character varying,
	IN p_icon character varying,
	IN p_isactive boolean,
	IN p_actionby character varying,
	IN p_actiondate timestamp without time zone,
	IN p_id bigint DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
--insert
IF p_id=0 THEN 
INSERT INTO menu(id,menuname,submenuname,menupath,submenupath,icon,isactive,actionby,actiondate)
VALUES(p_id,p_menuname,p_submenuname,p_menupath,p_submenupath,p_icon,p_isactive,p_actionby,p_actiondate);
END IF;

--update
IF p_id>0 AND EXISTS (SELECT 1 FROM menu WHERE id=p_id) THEN
UPDATE menu 
SET menuname=p_menuname,submenuname=p_submenuname,menupath=p_menupath,submenupath=p_submenupath,
icon=p_icon,isactive=p_isactive,actionby=p_actionby,actiondate=p_actiondate WHERE id=p_id;
END IF;

END
$BODY$;
ALTER PROCEDURE public.sp_menu(character varying, character varying, character varying, character varying, character varying, boolean, character varying, timestamp without time zone, bigint)
    OWNER TO postgres;
