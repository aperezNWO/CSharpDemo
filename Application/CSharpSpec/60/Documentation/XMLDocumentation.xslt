<?xml version="1.0"?>
<!-- To visualize the archive correctly, open it from the url "http://localhost/CSharpSpec/60/Xml/cdcatalog.xml" -->
<xsl:transform version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<html>
			<body>
				<h2>[C# DOCUMENTATION]</h2>
				<!-- To visualize the archive correctly, open it from the url "http://localhost/CSharpSpec/60/Xml/cdcatalog.xml" -->
				<table border="1">
					<tr bgcolor="#9acd32">
						<th>[Member-Name]</th>
						<th>[Summary]</th>
						<th>[Params]</th>
						<th>[Return]</th>
						<th>[Value]</th>
					</tr>
					<xsl:for-each select="doc/members/member">
						<tr>
							<td>
								<xsl:value-of select="@name" />
							</td>
							<td>
								<xsl:value-of select="summary"/>
							</td>
							<td>
								<ul>
									<xsl:for-each select="param">
										<li>
											[<xsl:value-of select="c"/>]
											<xsl:for-each select=".">
												-[<xsl:value-of select="text()"/>]
											</xsl:for-each>	
										</li>
									</xsl:for-each>
								</ul>
							</td>
							<td>
								<xsl:value-of select="returns"/>
							</td>
							<td>
								<xsl:value-of select="value"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:transform>
