<?xml version="1.0"?>
<!-- To visualize the archive correctly, open it from the url "http://localhost/CSharpSpec/60/Xml/cdcatalog.xml" -->
<xsl:transform version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<html>
			<body>
				<h2>[CD CATALOG]</h2>
				<!-- To visualize the archive correctly, open it from the url "http://localhost/CSharpSpec/60/Xml/cdcatalog.xml" -->
				<table border="1">
					<tr bgcolor="#9acd32">
						<th>Title</th>
						<th>Artist</th>
					</tr>
					<xsl:for-each select="catalog/cd">
						<tr>
							<td>
								<xsl:value-of select="title"/>
							</td>
							<td>
								<xsl:value-of select="artist"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:transform>
