FROM php:7-apache
COPY index.php /var/www/html/index.php
# EXPOSE 80
RUN echo "ServerName localhost" >> /etc/apache2/apache2.conf
CMD ["/usr/sbin/apache2ctl","-D","FOREGROUND"]