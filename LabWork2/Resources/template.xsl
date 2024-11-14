<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" encoding="UTF-8"/>
	<xsl:template match="/">
		<html>
			<head>
				<title>Дані проживання</title>
			</head>
			<body>
				<h2>Результати проживання у гуртожитку</h2>
				<table border="1">
					<tr>
						<th>Ім'я</th>
						<th>Факультет</th>
						<th>Курс</th>
						<th>Кімната</th>
						<th>Дата заселення</th>
						<th>Дата виселення</th>
					</tr>
					<xsl:for-each select="Dormitory/Person">
						<tr>
							<td>
								<xsl:value-of select="Name/FirstName"/>
								<xsl:text> </xsl:text>
								<xsl:value-of select="Name/LastName"/>
							</td>
							<td>
								<xsl:value-of select="Faculty"/>
							</td>
							<td>
								<xsl:value-of select="Course"/>
							</td>
							<td>
								<xsl:value-of select="Room"/>
							</td>
							<td>
								<xsl:value-of select="CheckInDate"/>
							</td>
							<td>
								<xsl:value-of select="CheckOutDate"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
