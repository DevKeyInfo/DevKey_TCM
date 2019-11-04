<?php 

class Config{

	//info básicas do site
	const SITE_URL = "http://localhost";
	const SITE_PASTA = "devkey";
	const SITE_NOME = "ORGANOGRAMA - DEVKEY";
	const SITE_EMAIL_ADM = "developmentkey@gmail.com";
	const SITE_TEL_ADM = "+55 11 9 7076 3349";
	//const BD_LIMIT_PAG = 10; //definir quantas <td> aparecerão por pag


	//info banco
	const BD_HOST = "localhost:3307",
		  BD_USER = "root",
		  BD_SENHA = "",
		  BD_BANCO = "devkey",
		  BD_PREFIX= "dev_";

	//info para php mailler
	const EMAIL_HOST = "smtp.gmail.com";
	const EMAIL_USER = "developmentkey@gmail.com";
	const EMAIL_NOME = "Contato DEVKEY - FAQ";
	const EMAIL_SENHA = "basilides2";
	const EMAIL_PORTA = 587;
	const EMAIL_SMTPAUTH = true;
	const EMAIL_SMTPSECURE = "tls";
	const EMAIL_COPIA = "developmentkey@gmail.com";

}

 ?>