-- PROCEDURE: public.sp_cartpage(bigint, bigint, integer, numeric, numeric, character varying, timestamp without time zone, boolean, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_cartpage(bigint, bigint, integer, numeric, numeric, character varying, timestamp without time zone, boolean, bigint);

CREATE OR REPLACE PROCEDURE public.sp_cartpage(
	IN p_userid bigint,
	IN p_productid bigint,
	IN p_quantity integer,
	IN p_price numeric,
	IN p_originalprice numeric,
	IN p_actionby character varying,
	IN p_actiondate timestamp without time zone,
	IN p_isactive boolean,
	IN p_id bigint DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN

--Insert
IF p_id = 0 THEN
INSERT INTO cartpage(userid, productid, quantity, price, originalprice, actionby, actiondate, isactive) 
VALUES (p_userid, p_productid, p_quantity, p_price, p_originalprice, p_actionby, p_actiondate, p_isactive);
END IF;

--update
IF p_id > 0 AND EXISTS (SELECT 1 FROM cartpage WHERE id=p_id) THEN
UPDATE cartpage SET userid = p_userid, productid = p_productid, quantity = p_quantity, price = p_price, originalprice = p_originalprice, actionby = p_actionby, actiondate = p_actiondate, isactive = p_isactive 
WHERE id=p_id;
END IF;

END

$BODY$;
ALTER PROCEDURE public.sp_cartpage(bigint, bigint, integer, numeric, numeric, character varying, timestamp without time zone, boolean, bigint)
    OWNER TO postgres;
