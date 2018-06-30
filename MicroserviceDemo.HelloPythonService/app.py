from flask import Flask, Response
from flask_jwt_extended import JWTManager, jwt_required, get_jwt_claims
from flask_cors import cross_origin

from cryptography.hazmat.primitives.asymmetric.rsa import RSAPublicNumbers
from cryptography.hazmat.backends import default_backend
from cryptography.hazmat.primitives import serialization

from datetime import datetime
from requests import get
import json
import argparse
import base64
import six
import struct


def intarr2long(arr):
    return int(''.join(["%02x" % byte for byte in arr]), 16)

def base64_to_long(data):
    if isinstance(data, six.text_type):
        data = data.encode("ascii")

    # urlsafe_b64decode will happily convert b64encoded data
    _d = base64.urlsafe_b64decode(bytes(data) + b'==')
    return intarr2long(struct.unpack('%sB' % len(_d), _d))

def jwk_to_pem(jwk):
    exponent = base64_to_long(jwk['e'])
    modulus = base64_to_long(jwk['n'])
    numbers = RSAPublicNumbers(exponent, modulus)
    public_key = numbers.public_key(backend=default_backend())
    pem = public_key.public_bytes(
        encoding=serialization.Encoding.PEM,
        format=serialization.PublicFormat.SubjectPublicKeyInfo
    )
    return pem

def load_publickey(url):
    keys = get(url).json()["keys"]
    return jwk_to_pem(keys[0])


app = Flask(__name__)
app.config.update(
    JWT_ALGORITHM = "RS256",
    JWT_IDENTITY_CLAIM = "sub",
    JWT_PUBLIC_KEY = load_publickey("http://localhost:5001/.well-known/openid-configuration/jwks"),
)
jwt = JWTManager(app)

@app.route("/api/message")
@jwt_required
@cross_origin(orrigins=["http://localhost:5005"], allow_headers="*")
def hello():
    message = "Hello from Python Service at " + str(datetime.now())
    return Response(message, mimetype="text/plain")

app.run(host="localhost", port=5004)